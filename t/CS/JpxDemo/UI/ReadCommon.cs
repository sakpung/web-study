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
   public partial class ReadCommon : Form
   {
      public ReadCommon()
      {
         InitializeComponent();

         ShowFilterType = true;
         DialogName = "Read Common";

         InitClass();
      }

      public ReadCommon(MainForm mainParenForm, string dialogName, bool showFilterType)
      {
         InitializeComponent();

         ShowFilterType = showFilterType;
         DialogName = dialogName;
         MainParenForm = mainParenForm;

         InitClass();
      }

      private string _dialogName;
      private bool _showFilterType;
      private ReadBoxCommonStructure _readBox;
      private MainForm _mainParenForm;

      public MainForm MainParenForm
      {
         get
         {
            return _mainParenForm;
         }
         set
         {
            _mainParenForm = value;
         }
      }

      public ReadBoxCommonStructure ReadBox
      {
         get
         {
            return _readBox;
         }
         set
         {
            _readBox = value;
         }
      }

      public bool ShowFilterType
      {
         get
         {
            return _showFilterType;
         }
         set
         {
            _showFilterType = value;
         }
      }
      public string DialogName
      {
         get
         {
            return _dialogName;
         }
         set
         {
            _dialogName = value;
         }
      }

      private void InitClass()
      {
         this.Text = "Read " + DialogName + " Box Dialog";

         _lblSecond.Text = DialogName + " Box Data File:";

         _btnRead.Enabled = false;

         UpdateFilterTypeControls();
      }

      private void UpdateFilterTypeControls()
      {
         if (ShowFilterType)
            return;

         _grpFilterType.Visible = false;
         _txtFilterType.Visible = false;

         _grpBoxIndex.Location = new Point(_grpBoxIndex.Location.X, _grpBoxIndex.Location.Y - _grpFilterType.Height);
         _btnRead.Location = new Point(_btnRead.Location.X, _btnRead.Location.Y - _grpFilterType.Height);
         this.Height -= _grpFilterType.Height;
      }

      private void _btnJPEG2000Browse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "All Files (*.*)|*.*";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000.Text = ofd.FileName;
            _btnRead.Enabled = true;
         }
      }

      private void _btnSecondBrowse_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();

         sfd.Title = "Save a File";
         sfd.Filter = "All Files (*.*)|*.*";

         if (sfd.ShowDialog() == DialogResult.OK)
         {
            _txtSecond.Text = sfd.FileName;
         }
      }


      private void _btnRead_Click(object sender, EventArgs e)
      {
         if (_txtJPEG2000.Text == "")
         {
            Messager.ShowError(this, "Please select images to read");
            return;
         }

         int boxIndex;
         bool result = true;
         Jpeg2000FileInformation _fileInformation;

         //Get Box number
         boxIndex = Convert.ToInt32(_nudBoxIndex.Value);

         try
         {
            _fileInformation = (Jpeg2000FileInformation)MainParenForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return;
         }

         switch (ReadBox.boxType)
         {
            case Jpeg2000BoxType.IprBox:
               result = CheckAndSave(boxIndex, (_fileInformation.IntellectualPropertyRights != null) ? _fileInformation.IntellectualPropertyRights.Length : 0);
               break;

            case Jpeg2000BoxType.XmlBox:
               result = CheckAndSave(boxIndex, (_fileInformation.Xml != null) ? _fileInformation.Xml.Length : 0);
               break;

            case Jpeg2000BoxType.Mpeg7Box:
               result = CheckAndSave(boxIndex, (_fileInformation.Mpeg7 != null) ? _fileInformation.Mpeg7.Length : 0);
               break;

            case Jpeg2000BoxType.MediaDataBox:
               result = CheckAndSave(boxIndex, (_fileInformation.MediaData != null) ? _fileInformation.MediaData.Length : 0);
               break;

            case Jpeg2000BoxType.FreeBox:
               result = CheckAndSave(boxIndex, (_fileInformation.Free != null) ? _fileInformation.Free.Length : 0);
               break;

            case Jpeg2000BoxType.GtsoBox:
               result = CheckAndSave(boxIndex, (_fileInformation.DesiredReproduction != null) ? _fileInformation.DesiredReproduction.Length : 0);
               break;

            case Jpeg2000BoxType.BinaryFilterBox:
               result = BinaryFilterProcess();
               break;

            case Jpeg2000BoxType.AssociationBox:
               result = CheckAndSave(boxIndex, (_fileInformation.Association != null) ? _fileInformation.Association.Length : 0);
               break;
         }
         if(result)
         {
            Messager.ShowInformation(this, "Read succeeded");
            if (ReadBox.boxType != Jpeg2000BoxType.BinaryFilterBox)
            {
               this.DialogResult = DialogResult.OK;
               this.Close();
            }
         }
      }

      private bool ReadCommonSaveData(byte[] data)
      {
         try
         {
            FileStream _readFile = File.Open(_txtSecond.Text, FileMode.Create);
            _readFile.Write(data, 0, data.Length);
            _readFile.Close();
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
         return true;
      }

      private bool CheckAndSave(int boxIndex, int boxTypeLength)
      {
         if (boxTypeLength == -1 || boxIndex >= boxTypeLength)
         {
            if(boxTypeLength > 0)
               Messager.ShowError(this, string.Format("Box Index should be less than {0}.", boxTypeLength));
            else
               Messager.ShowError(this, string.Format("The file has no box of this type."));
            return false;
         }

         Jpeg2000Box tempReadBox;
         try
         {
            tempReadBox = MainParenForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, ReadBox.boxType, boxIndex);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         switch(ReadBox.boxType)
         {
            case Jpeg2000BoxType.IprBox: ReadCommonSaveData(((IprBox) tempReadBox).Data); break;
            case Jpeg2000BoxType.XmlBox: ReadCommonSaveData(((XmlBox) tempReadBox).Data); break;
            case Jpeg2000BoxType.Mpeg7Box: ReadCommonSaveData(((Mpeg7Box) tempReadBox).Data); break;
            case Jpeg2000BoxType.MediaDataBox: ReadCommonSaveData(((MediaDataBox)tempReadBox).Data); break;
            case Jpeg2000BoxType.FreeBox: ReadCommonSaveData(((FreeBox)tempReadBox).Data); break;
            case Jpeg2000BoxType.GtsoBox: ReadCommonSaveData(((GtsoBox)tempReadBox).Data); break;
            case Jpeg2000BoxType.AssociationBox: ReadCommonSaveData(((AssociationBox)tempReadBox).Data); break;
         }
         return true;
      }

      private bool BinaryFilterProcess()
      {
         int                        boxIndex;
         Jpeg2000FileInformation    fileInfo;
         BinaryFilterBox            _binaryFilterBox;

         //Get Jpeg 2000 file name
         if(_txtJPEG2000.Text == "")
         {
            Messager.ShowError(this, "Please select a JPEG 2000 file");
            return false;
         }

         if(_txtSecond.Text == "")
         {
            Messager.ShowError(this, "Please select a data file");
            return false;
         }

         //Get Box number
         boxIndex = Convert.ToInt32(_nudBoxIndex.Value);

         try
         {
            fileInfo = MainParenForm.Jpeg2000Eng.GetFileInformation(_txtJPEG2000.Text);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         if (fileInfo.BinaryFilter == null || boxIndex >= fileInfo.BinaryFilter.Length)
         {
            Messager.ShowError(this, string.Format("Box Index should be less than {0}.", (fileInfo.BinaryFilter == null) ? 0 : fileInfo.BinaryFilter.Length));
            return false;
         }

         try
         {
            _binaryFilterBox = (BinaryFilterBox) MainParenForm.Jpeg2000Eng.ReadBox(_txtJPEG2000.Text, Jpeg2000BoxType.BinaryFilterBox, boxIndex);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }

         if(ReadBinaryFilterSaveData(_binaryFilterBox.Data))
         {
            _txtFilterType.Text = string.Format(
                                  "{0:x2}{0:x2}{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}-{0:x2}{0:x2}{0:x2}{0:x2}{0:x2}{0:x2}",
                                  _binaryFilterBox.FilterType.Id[0],
                                  _binaryFilterBox.FilterType.Id[1],
                                  _binaryFilterBox.FilterType.Id[2],
                                  _binaryFilterBox.FilterType.Id[3],
                                  _binaryFilterBox.FilterType.Id[4],
                                  _binaryFilterBox.FilterType.Id[5],
                                  _binaryFilterBox.FilterType.Id[6],
                                  _binaryFilterBox.FilterType.Id[7],
                                  _binaryFilterBox.FilterType.Id[8],
                                  _binaryFilterBox.FilterType.Id[9],
                                  _binaryFilterBox.FilterType.Id[10],
                                  _binaryFilterBox.FilterType.Id[11],
                                  _binaryFilterBox.FilterType.Id[12],
                                  _binaryFilterBox.FilterType.Id[13],
                                  _binaryFilterBox.FilterType.Id[14],
                                  _binaryFilterBox.FilterType.Id[15]);
         }
         return true;
      }

      bool ReadBinaryFilterSaveData(byte[] data)
      {
         try
         {
            FileStream _readFile = File.Open(_txtSecond.Text, FileMode.Create);
            _readFile.Write(data, 0, data.Length);
            _readFile.Close();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
         return true;
      }
   }
}
