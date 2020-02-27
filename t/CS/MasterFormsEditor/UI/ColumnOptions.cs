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
using Leadtools.Forms.Processing;
using Leadtools.Ocr;

namespace CSMasterFormsEditor
{
   public partial class ColumnOptions : Form
   {
      private OcrFormField _ocrField;
      private TableColumn _column;
      private bool stopUpdate = false;

      public TableColumn Column
      {
         get
         {
            return _column;
         }
         set
         {
            _column = value;
            _ocrField=value.OcrField;
            stopUpdate = true;
            if (value != null)
            {
               _nudLeft.Value = (int) _ocrField.Bounds.Left;
               _nudTop.Value = (int)_ocrField.Bounds.Top;
               _nudWidth.Value = (int)_ocrField.Bounds.Width;
               _nudHeight.Value = (int)_ocrField.Bounds.Height;

               _txt_ColumnOptionsFieldName.Text = _ocrField.Name;

               _cbIsKeyColumn.Checked = this.Column.IsKeyColumn;

               if(_ocrField is TextFormField)
               {
                  _gb_OcrColumnOption.Enabled=true;
                  _gb_OmrColumnOptions.Enabled=false;

                  TextFormField textField = _ocrField as TextFormField;

                  _chkEnableIcr.Checked = textField.EnableIcr;
                  _chkEnableOcr.Checked = textField.EnableOcr;
                  _rbTextTypeChar.Checked = (textField.Type == TextFieldType.Character);
                  _rbtextTypeNum.Checked = (textField.Type == TextFieldType.Numerical);

               }
               else if (_ocrField is OmrFormField)
               {
                  _gb_OcrColumnOption.Enabled=false;
                  _gb_OmrColumnOptions.Enabled=true;

                  OmrFormField omrField = _ocrField as OmrFormField;

                  _rbOMRWithFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.WithFrame;
                  _rbOMRWithoutFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.WithoutFrame;
                  _rbOMRAutoFrame.Checked = omrField.FrameMethod == OcrOmrFrameDetectionMethod.Auto;
                  _rbOMRSensitivityLowest.Checked = omrField.Sensitivity == OcrOmrSensitivity.Lowest;
                  _rbOMRSensitivityLow.Checked = omrField.Sensitivity == OcrOmrSensitivity.Low;
                  _rbOMRSensitivityHigh.Checked = omrField.Sensitivity == OcrOmrSensitivity.High;
                  _rbOMRSensitivityHighest.Checked = omrField.Sensitivity == OcrOmrSensitivity.Highest;
               }
            }
            else
            {
               _nudLeft.Value = 0;
               _nudTop.Value = 0;
               _nudWidth.Value = 0;
               _nudHeight.Value = 0;
               _txt_ColumnOptionsFieldName.Text = "";
            }
            stopUpdate = false;
         }
      }

      public ColumnOptions(bool enableIcr)
      {
         InitializeComponent();

         if(!enableIcr)
            _chkEnableIcr.Enabled = false;
      }

      private void UpdateField()
      {
         //One or more of the fields properties changed so we need to update the field data
         //which is stored in the annotation objects UserData
         FormField currentField = _ocrField;
         string fieldType = (currentField is TextFormField) ? "Text" : "Omr";

         switch (fieldType)
         {
            case "Text":
               if (!(currentField is TextFormField))
                  currentField = new TextFormField();

               //set text field options
               (currentField as TextFormField).EnableIcr = _chkEnableIcr.Checked;
               (currentField as TextFormField).EnableOcr = _chkEnableOcr.Checked;
               (currentField as TextFormField).Type = _rbTextTypeChar.Checked ? TextFieldType.Character : TextFieldType.Numerical;
               break;

            case "Omr":
               if (!(currentField is OmrFormField))
                  currentField = new OmrFormField();

               //set omr field options
               if (_rbOMRWithFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithFrame;
               else if (_rbOMRWithoutFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame;
               else if (_rbOMRAutoFrame.Checked)
                  (currentField as OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.Auto;

               if (_rbOMRSensitivityLowest.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Lowest;
               else if (_rbOMRSensitivityLow.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Low;
               else if (_rbOMRSensitivityHigh.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.High;
               else if (_rbOMRSensitivityHighest.Checked)
                  (currentField as OmrFormField).Sensitivity = OcrOmrSensitivity.Highest;
               break;           
         }

         currentField.Bounds = new LeadRect(Convert.ToInt32(_nudLeft.Value), Convert.ToInt32(_nudTop.Value), Convert.ToInt32(_nudWidth.Value), Convert.ToInt32(_nudHeight.Value));
         currentField.Name = _txt_ColumnOptionsFieldName.Text;
         _chkDropoutWords.Checked = (currentField.Dropout & DropoutFlag.WordsDropout) == DropoutFlag.WordsDropout;
         _chkDropoutCells.Checked = (currentField.Dropout & DropoutFlag.CellsDropout) == DropoutFlag.CellsDropout;
      }

      private void OptionsChanged(object sender, EventArgs e)
      {
         if (!stopUpdate)
            UpdateField();
      }

      private void _cbIsKeyColumn_CheckedChanged(object sender, EventArgs e)
      {
         this.Column.IsKeyColumn = _cbIsKeyColumn.Checked;
      }

      private void _chkDropoutWords_CheckedChanged(object sender, EventArgs e)
      {
         FormField currentField = _ocrField;
         if (this._chkDropoutWords.Checked == true)
         {
            currentField.Dropout |= DropoutFlag.WordsDropout;
         }
         else
         {
            currentField.Dropout &= ~DropoutFlag.WordsDropout;
         }
      }

      private void _chkDropoutCells_CheckedChanged(object sender, EventArgs e)
      {
         FormField currentField = _ocrField;
         if (this._chkDropoutCells.Checked == true)
         {
            currentField.Dropout |= DropoutFlag.CellsDropout;
         }
         else
         {
            currentField.Dropout &= ~DropoutFlag.CellsDropout;
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
