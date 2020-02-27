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
using System.Collections;
using System.Drawing.Drawing2D;

namespace JPXDemo
{
   public partial class FileInformation : Form
   {
      public FileInformation(MainForm mainForm)
      {
         _mainForm = mainForm;

         InitializeComponent();

         InitClass();
      }

      private MainForm _mainForm;
      private JPXFileInfoStructure _dialogJPXFileInformation;

      private Color[] _colors   ={
                        Color.FromArgb(255, 0, 0),           //0  Association
                        Color.FromArgb(255, 128, 0),         //1  BinaryFilter
                        Color.FromArgb(255, 0, 128),         //2  CodeStream
                        Color.FromArgb(128, 0, 0),           //3  Composition
                        Color.FromArgb(0, 255, 0),           //4  DataRef
                        Color.FromArgb(128, 128, 0),         //5  DesiredReproduction
                        Color.FromArgb(0, 0, 128),           //6  DigitalSignature
                        Color.FromArgb(0, 128, 0),           //7  Free
                        Color.FromArgb(0, 0, 255),           //8  Header
                        Color.FromArgb(0, 128, 255),         //9  IPR
                        Color.FromArgb(128, 0, 255),         //10 MPEG7
                        Color.FromArgb(0, 0, 128),           //11 UUID
                        Color.FromArgb(255, 0, 255),         //12 UUIDInfo
                        Color.FromArgb(255, 255, 0),         //13 XML
                        Color.FromArgb(128, 0, 128),         //14.MediaData
                        Color.FromArgb(128, 128, 0),         //
                        Color.FromArgb(0, 255, 255),         //
                        Color.FromArgb(128, 255, 255)};      //

      private string[] _colorsText = {
                           "Association",
                           "BinaryFilter",
                           "CodeStream",
                           "Composition",
                           "Data Reference",
                           "DesiredReproduction",
                           "DigitalSignature",
                           "Free",
                           "Header",
                           "IPR",
                           "MPEG7",
                           "UUID",
                           "UUIDInfo",
                           "XML",
                           "Media Data"};

      private const int _paintMinimumHeight = 20;
      private const int _boxCount = 15;
      private const int _textToFrameHollow = 5;
      private const int _textAdditionalHeight = 5;

      private void InitClass()
      {
         _dialogJPXFileInformation.prepared = false;
         _dialogJPXFileInformation.boxesNumber = 0;
         _dialogJPXFileInformation.boxesNumber = 0;

         _btnGetInfo.Enabled = false;
      }

      private void _btnJPEG2000Browse_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Title = "Open a File";
         ofd.Filter = "JPX Files(*.jpx)|*.jpx|JP2 Files(*.jp2)|*.jp2";

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            _txtJPEG2000FileName.Text = ofd.FileName;
            _btnGetInfo.Enabled = true;
         }
      }

      private void _btnGetInfo_Click(object sender, EventArgs e)
      {
         if (_txtJPEG2000FileName.Text == "")
         {
            Messager.ShowError(this, "Please select a file");
            return;
         }

         FileInformationProcess();
         _grpFileMemoryOrganization.Invalidate(true);
      }

      private Rectangle GetTextRectangle(string drawText, Font textFont, Rectangle box)
      {
         Rectangle textRectangle;
         GraphicsPath graphicsPath = new GraphicsPath();

         graphicsPath.AddString(drawText, textFont.FontFamily,(int) FontStyle.Regular, textFont.Size, new Point(0), null);

         textRectangle = Rectangle.Round(graphicsPath.GetBounds());

         return (new Rectangle(((box.Width / 2) - (textRectangle.Width / 2)), box.Y + _textToFrameHollow, textRectangle.Width, textRectangle.Height + _textAdditionalHeight));
      }

      private bool FileInformationProcess()
      {
         _dialogJPXFileInformation.fileInformation = new Jpeg2000FileInformation();
         _dialogJPXFileInformation.fileName = _txtJPEG2000FileName.Text;

         try
         {
            _dialogJPXFileInformation.fileInformation = (Jpeg2000FileInformation) _mainForm.Jpeg2000Eng.GetFileInformation(_dialogJPXFileInformation.fileName);

            FileInformationPrepareData();

            _txtNOFrames.Text = _dialogJPXFileInformation.fileInformation.Frame.Length.ToString();

            if (_dialogJPXFileInformation.fileInformation.Format == Jpeg2000FileFormat.LeadJpx)
               _txtFormat.Text = "JPX";
            else
               _txtFormat.Text = "JP2";

            if (_dialogJPXFileInformation.fileInformation.Association != null)
               _txtAssociation.Text = (_dialogJPXFileInformation.fileInformation.Association.Length).ToString();
            else
               _txtAssociation.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.BinaryFilter != null)
               _txtBinaryFilter.Text = (_dialogJPXFileInformation.fileInformation.BinaryFilter.Length).ToString();
            else
               _txtBinaryFilter.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.CodeStream != null)
               _txtCodeStream.Text = (_dialogJPXFileInformation.fileInformation.CodeStream.Length).ToString();
            else
               _txtCodeStream.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Composition != null)
               _txtComposition.Text = (_dialogJPXFileInformation.fileInformation.Composition.Length).ToString();
            else
               _txtComposition.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.DataReference != null)
               _txtDataReference.Text = (_dialogJPXFileInformation.fileInformation.DataReference.Length).ToString();
            else
               _txtDataReference.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.DesiredReproduction != null)
               _txtDesiredReproduction.Text = (_dialogJPXFileInformation.fileInformation.DesiredReproduction.Length).ToString();
            else
               _txtDesiredReproduction.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.DigitalSignature != null)
               _txtDigitalSignature.Text = (_dialogJPXFileInformation.fileInformation.DigitalSignature.Length).ToString();
            else
               _txtDigitalSignature.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Free != null)
               _txtFree.Text = (_dialogJPXFileInformation.fileInformation.Free.Length).ToString();
            else
               _txtFree.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Header != null)
               _txtHeader.Text = (_dialogJPXFileInformation.fileInformation.Header.Length).ToString();
            else
               _txtHeader.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights != null)
               _txtIPR.Text = (_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length).ToString();
            else
               _txtIPR.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Mpeg7 != null)
               _txtMPEG7.Text = (_dialogJPXFileInformation.fileInformation.Mpeg7.Length).ToString();
            else
               _txtMPEG7.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Uuid != null)
               _txtUUID.Text = (_dialogJPXFileInformation.fileInformation.Uuid.Length).ToString();
            else
               _txtUUID.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.UuidInformation != null)
               _txtUUIDInfo.Text = (_dialogJPXFileInformation.fileInformation.UuidInformation.Length).ToString();
            else
               _txtUUIDInfo.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.Xml != null)
               _txtXML.Text = (_dialogJPXFileInformation.fileInformation.Xml.Length).ToString();
            else
               _txtXML.Text = "0";
            if (_dialogJPXFileInformation.fileInformation.MediaData != null)
               _txtMediaData.Text = (_dialogJPXFileInformation.fileInformation.MediaData.Length).ToString();
            else
               _txtMediaData.Text = "0";
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
         return true;
      }

      public void FileInformationPrepareData()
      {
         uint numberOfBoxes, index, groupCount;
         int  counter;

         numberOfBoxes = 0;
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Association != null) ? _dialogJPXFileInformation.fileInformation.Association.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.BinaryFilter != null) ? _dialogJPXFileInformation.fileInformation.BinaryFilter.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.CodeStream != null) ? _dialogJPXFileInformation.fileInformation.CodeStream.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Composition != null) ? _dialogJPXFileInformation.fileInformation.Composition.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.DataReference != null) ? _dialogJPXFileInformation.fileInformation.DataReference.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.DesiredReproduction != null) ? _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.DigitalSignature != null) ? _dialogJPXFileInformation.fileInformation.DigitalSignature.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Free != null) ? _dialogJPXFileInformation.fileInformation.Free.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Header != null) ? _dialogJPXFileInformation.fileInformation.Header.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights != null) ? _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Mpeg7 != null) ? _dialogJPXFileInformation.fileInformation.Mpeg7.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Uuid != null) ? _dialogJPXFileInformation.fileInformation.Uuid.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.UuidInformation != null) ? _dialogJPXFileInformation.fileInformation.UuidInformation.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.Xml != null) ? _dialogJPXFileInformation.fileInformation.Xml.Length : 0);
         numberOfBoxes += (uint)((_dialogJPXFileInformation.fileInformation.MediaData != null) ? _dialogJPXFileInformation.fileInformation.MediaData.Length : 0);

         _dialogJPXFileInformation.boxes = new FileInformationSortStructure[numberOfBoxes];
         _dialogJPXFileInformation.boxesNumber = numberOfBoxes;

         index = 0;
         _dialogJPXFileInformation.totalSize = 0;

         if (_dialogJPXFileInformation.fileInformation.Association != null && _dialogJPXFileInformation.fileInformation.Association.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Association.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 0;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Association[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Association[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.BinaryFilter != null && _dialogJPXFileInformation.fileInformation.BinaryFilter.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.BinaryFilter.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 1;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.BinaryFilter[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.BinaryFilter[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.CodeStream != null && _dialogJPXFileInformation.fileInformation.CodeStream.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.CodeStream.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 2;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.CodeStream[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.CodeStream[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.Composition != null && _dialogJPXFileInformation.fileInformation.Composition.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Composition.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 3;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Composition[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Composition[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.DataReference != null && _dialogJPXFileInformation.fileInformation.DataReference.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.DataReference.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 4;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.DataReference[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.DataReference[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.DesiredReproduction != null && _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.DesiredReproduction.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 5;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.DesiredReproduction[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.DesiredReproduction[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.DigitalSignature != null && _dialogJPXFileInformation.fileInformation.DigitalSignature.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.DigitalSignature.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 6;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.DigitalSignature[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.DigitalSignature[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.Free != null && _dialogJPXFileInformation.fileInformation.Free.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Free.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 7;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Free[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Free[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.Header != null && _dialogJPXFileInformation.fileInformation.Header.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Header.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 8;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Header[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Header[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.IntellectualPropertyRights != null && _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 9;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.IntellectualPropertyRights[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }


         if (_dialogJPXFileInformation.fileInformation.Mpeg7 != null && _dialogJPXFileInformation.fileInformation.Mpeg7.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Mpeg7.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 10;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Mpeg7[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Mpeg7[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.Uuid != null && _dialogJPXFileInformation.fileInformation.Uuid.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Uuid.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 11;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Uuid[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Uuid[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.UuidInformation != null && _dialogJPXFileInformation.fileInformation.UuidInformation.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.UuidInformation.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 12;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.UuidInformation[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.UuidInformation[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.Xml != null && _dialogJPXFileInformation.fileInformation.Xml.Length != 0)
         {
            for(counter = 0; counter < _dialogJPXFileInformation.fileInformation.Xml.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 13;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.Xml[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.Xml[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         if (_dialogJPXFileInformation.fileInformation.MediaData != null && _dialogJPXFileInformation.fileInformation.MediaData.Length != 0)
         {
            for (counter = 0; counter < _dialogJPXFileInformation.fileInformation.MediaData.Length; counter++)
            {
               _dialogJPXFileInformation.boxes[index].type = 14;
               _dialogJPXFileInformation.boxes[index].offset = (uint) _dialogJPXFileInformation.fileInformation.MediaData[counter].BoxOffset;
               _dialogJPXFileInformation.boxes[index].size = (uint) _dialogJPXFileInformation.fileInformation.MediaData[counter].BoxSize;
               _dialogJPXFileInformation.totalSize += _dialogJPXFileInformation.boxes[index].size;
               index++;
            }
         }

         IComparer comparer = new MyComaprer();
         Array.Sort(_dialogJPXFileInformation.boxes, comparer);

         for(counter = 1, groupCount = 1; counter < _dialogJPXFileInformation.boxesNumber; counter++)
         {
            if(_dialogJPXFileInformation.boxes[counter].type != _dialogJPXFileInformation.boxes[counter-1].type)
               groupCount++;
         }
         _dialogJPXFileInformation.groups = new FileInformationSortStructure[groupCount];
         _dialogJPXFileInformation.groupsNumber = groupCount;

         _dialogJPXFileInformation.groups[0].type   = _dialogJPXFileInformation.boxes[0].type;
         _dialogJPXFileInformation.groups[0].offset = _dialogJPXFileInformation.boxes[0].offset;
         _dialogJPXFileInformation.groups[0].size   = _dialogJPXFileInformation.boxes[0].size;

         for(counter = 1, index = 0; counter < _dialogJPXFileInformation.boxesNumber; counter++)
         {
            if(_dialogJPXFileInformation.groups[index].type != _dialogJPXFileInformation.boxes[counter].type)
            {
               index++;
               _dialogJPXFileInformation.groups[index].type   = _dialogJPXFileInformation.boxes[counter].type;
               _dialogJPXFileInformation.groups[index].offset = _dialogJPXFileInformation.boxes[counter].offset;
               _dialogJPXFileInformation.groups[index].size   = _dialogJPXFileInformation.boxes[counter].size;
         
            }
            else
               _dialogJPXFileInformation.groups[index].size += _dialogJPXFileInformation.boxes[counter].size;
         }
         _dialogJPXFileInformation.prepared = true;
      }

      private void _lblFileMemoryOrganization_Paint(object sender, PaintEventArgs e)
      {
         int index;
         Rectangle textRectangle;
         Font textFont = new Font("Arial", 7);

         e.Graphics.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), _lblFileMemoryOrganization.Size));

         if (_dialogJPXFileInformation.prepared)
         {
            Rectangle box = new Rectangle(0, 0, _lblFileMemoryOrganization.Width, 0);

            int cyClientBoxes = Convert.ToInt32(_lblFileMemoryOrganization.Height - (_dialogJPXFileInformation.groupsNumber) * _paintMinimumHeight);

            for (index = 0; index < _dialogJPXFileInformation.groupsNumber; index++)
            {
               box = new Rectangle(new Point(0, box.Y), new Size(box.Width, Convert.ToInt32(((_dialogJPXFileInformation.groups[index].offset + _dialogJPXFileInformation.groups[index].size) *
                                                                       Convert.ToDouble(cyClientBoxes) / _dialogJPXFileInformation.totalSize +
                                                                       (index + 1) * _paintMinimumHeight - box.Y))));

               SolidBrush groupBrush = new SolidBrush(_colors[_dialogJPXFileInformation.groups[index].type]);
               e.Graphics.FillRectangle(groupBrush, box);
               e.Graphics.DrawRectangle(Pens.Black, box);
               string text = string.Format(", {0} Bytes", _dialogJPXFileInformation.groups[index].size);

               string drawText = string.Concat(_colorsText[_dialogJPXFileInformation.groups[index].type], text);
               Size textSize = Size.Round(e.Graphics.MeasureString(drawText, textFont));

               textRectangle = GetCenteredTextRectangle(box, textSize);

               e.Graphics.FillRectangle(Brushes.White, textRectangle);
               e.Graphics.DrawString(drawText, textFont, Brushes.Black, textRectangle);

               box = new Rectangle(new Point(box.X, box.Bottom), box.Size);
            }
         }
      }

      private Rectangle GetCenteredTextRectangle(Rectangle box, Size textSize)
      {
         int differnceWidth = box.Width - textSize.Width;
         int differenceHeight = box.Height - textSize.Height;

         int locationY = Convert.ToInt32(box.Y + differenceHeight / 2);
         int locationX = Convert.ToInt32(box.X + differnceWidth / 2);

         return (new Rectangle(locationX,
                               locationY,
                               textSize.Width,
                               textSize.Height));
      }

      private void _lbl_Paint(object sender, PaintEventArgs e)
      {
         Label control = (Label)sender;
         e.Graphics.FillRectangle(new SolidBrush(_colors[control.TabIndex]), new Rectangle(new Point(0, 0), control.Size));
      }
   }

   public class MyComaprer : IComparer
   {
      int IComparer.Compare(Object string1, object string2)
      {
         FileInformationSortStructure fileInformationSort1, fileInformationSort2;

         fileInformationSort1 = (FileInformationSortStructure)string1;
         fileInformationSort2 = (FileInformationSortStructure)string2;

         return (int)(fileInformationSort1.offset - fileInformationSort2.offset);
      }
   }

}
