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
using System.IO;

namespace JPXDemo
{
   public partial class FragmentJPX : Form
   {
      public FragmentJPX(MainForm mainParentForm)
      {
         InitializeComponent();

         _mainParentForm = mainParentForm;
      }

      private MainForm _mainParentForm;
      private FragmentJpxStructure _fragmentJpx;
      private Jpeg2000FileInformation _fileInformation;

      private void _btnInputBrowse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "All Files (*.*)|*.*";

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

      private void _btnCodeStreamsFiles_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();

         sfd.Title = "Save a File";
         sfd.Filter = "All Files (*.*)|*.*";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            _txtCodeStreamsFiles.Text = sfd.FileName;
         }
      }

      private bool FragmentProcess()
      {
         int index, offset;
         List<UuidUrl> url = new List<UuidUrl>(1);
         List<Fragment> fragments;

         _fragmentJpx = new FragmentJpxStructure();

         //Get Input Jpeg 2000 file name
         _fragmentJpx.inJPG2FileName = _txtInputFile.Text;

         //Get Output Jpeg 2000 file name
         _fragmentJpx.outJPG2FileName = _txtOutputFile.Text;

         //Get Stream file name
         _fragmentJpx.streamFileName = _txtCodeStreamsFiles.Text;

         try
         {
            _fileInformation = (Jpeg2000FileInformation)_mainParentForm.Jpeg2000Eng.GetFileInformation(_fragmentJpx.inJPG2FileName);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         //if(_fileInformation.Format != Jpeg2000FileFormat.LeadJpx || _fileInformation.FragmentTable.Length > 0)
         if (_fileInformation.Format != Jpeg2000FileFormat.LeadJpx || _fileInformation.FragmentTable != null)
         {
            Messager.ShowError(this, "The input file is not in JPX format or already fragmented");
            return false;
         }

         UuidUrl UuidUrlItem = new UuidUrl();
         UuidUrlItem.Flag = new byte[3];
         UuidUrlItem.Flag[0] = 0;
         UuidUrlItem.Flag[1] = 0;
         UuidUrlItem.Flag[2] = 0;
         UuidUrlItem.Version = 0;

         System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
         byte [] filename = encoding.GetBytes(_fragmentJpx.streamFileName);
         UuidUrlItem.Location = new byte[filename.Length + 2];
         Array.Copy(filename, UuidUrlItem.Location, filename.Length);
         UuidUrlItem.Location[filename.Length] = 0;//null termination
         UuidUrlItem.Location[filename.Length+1] = 0;//null termination
         url.Add(UuidUrlItem);

         fragments = new List<Fragment>();

         for (index = 0, offset = 0; index < _fileInformation.CodeStream.Length; index++)
         {
            Fragment fragmenItem = new Fragment();
            fragmenItem.UrlIndex = 1;
            fragmenItem.CodeStreamIndex = Convert.ToInt32(index);
            fragmenItem.Offset = offset;
            offset += Convert.ToInt32(_fileInformation.CodeStream[index].DataSize);
            fragments.Add(fragmenItem);
         }

         try
         {
            _mainParentForm.Jpeg2000Eng.FragmentJpxFile(_fragmentJpx.inJPG2FileName, _fragmentJpx.outJPG2FileName, url, fragments);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         FragmentSaveStreamFile(_fragmentJpx.streamFileName, _fragmentJpx.inJPG2FileName, _fileInformation);

         return true;
      }

     private bool FragmentSaveStreamFile(string streamFileName, string inFileName, Jpeg2000FileInformation fileInformation)
     {
        int index;
        byte[] buffer;

        //Load Box Data File
        FileStream streamFile = File.Open(streamFileName, FileMode.Create);

        if(streamFile == null)
        {
           return false;
        }

        FileStream inFile = File.Open(inFileName, FileMode.Open);
        if(inFile == null)
        {
           return false;
        }

        buffer = new byte[inFile.Length];
        if(buffer == null)
        {
           return false;
        }

        for (index = 0; index < fileInformation.CodeStream.Length; index++)
        {
           inFile.Seek(fileInformation.CodeStream[index].DataOffset, SeekOrigin.Begin);
           inFile.Read(buffer, 0, Convert.ToInt32(fileInformation.CodeStream[index].DataSize));
           streamFile.Write(buffer, 0, Convert.ToInt32(fileInformation.CodeStream[index].DataSize));
        }
        inFile.Close();
        streamFile.Close();
        return true;
     }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         if (_txtInputFile.Text == "")
         {
            Messager.ShowError(this, "Please select the input file");
            return;
         }

         if (_txtOutputFile.Text == "")
         {
            Messager.ShowError(this, "Please select the output file");
            return;
         }

         if (_txtCodeStreamsFiles.Text == "")
         {
            Messager.ShowError(this, "Please set the stream file");
            return;
         }

         if (FragmentProcess())
         {
            Messager.ShowInformation(this, "File was fragmented successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         else
            Messager.ShowError(this, "Error fragmenting the file!");
      }
   }
}
