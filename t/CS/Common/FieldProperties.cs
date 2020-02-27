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

using Leadtools.Demos;

namespace FormsDemo
{
   public partial class FieldProperties : Form
   {
      private bool _enableOcr;
      private bool _enableIcr;
      private bool _isNumerical;
      private string _name;
      private ProcessingFieldType _type;
      private double _left;
      private double _top;
      private double _width;
      private double _height;

      public FieldProperties(string name, ProcessingFieldType type, LogicalRectangle bounds, bool enableIcr, bool enableOcr, bool isNumerical, bool isICRSupported)
      {
         InitializeComponent();

         this.Text = "\"" + name + "\"" + " Properties";

         if (type == ProcessingFieldType.Text)
         {
            _methodGroup.Enabled = true;
            _typeGroup.Enabled = true;
            _enableOcr = enableOcr;
            _chkEnableOcr.Checked = enableOcr;

            _enableIcr = enableIcr;
            _chkEnableIcr.Checked = enableIcr && isICRSupported;

            _isNumerical = isNumerical;
            _radioTextNumerical.Checked = isNumerical;
            _radioTextCharacter.Checked = !isNumerical;
         }
         else
         {
            _methodGroup.Enabled = false;
            _typeGroup.Enabled = false;

            _enableOcr = true;
            _chkEnableOcr.Checked = true;

            _enableIcr = false;
            _chkEnableIcr.Checked = false;

            _isNumerical = false;
            _radioTextNumerical.Checked = false;
            _radioTextCharacter.Checked = true;
         }

         _chkEnableIcr.Enabled = isICRSupported;

         _name = name;
         _txtName.Text = name;

         _type = type;
         _cmbType.Text = type.ToString();

         _left = bounds.Left;
         _txtLeft.Text = bounds.Left.ToString();

         _top = bounds.Top;
         _txtTop.Text = bounds.Top.ToString();

         _width = bounds.Width;
         _txtWidth.Text = bounds.Width.ToString();

         _height = bounds.Height;
         _txtHeight.Text = bounds.Height.ToString();
      }

      private ProcessingFieldType ConvertToProcessingFieldType(string type)
      {
         ProcessingFieldType returnType = ProcessingFieldType.None;

         switch (type)
         {
            case "Barcode":
               returnType = ProcessingFieldType.Barcode;
               break;

            case "Image":
               returnType = ProcessingFieldType.Image;
               break;

            case "None":
               returnType = ProcessingFieldType.None;
               break;

            case "Text":
               returnType = ProcessingFieldType.Text;
               break;

            case "Omr":
               returnType = ProcessingFieldType.Omr;
               break;
         }

         return returnType;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _enableOcr   = _chkEnableOcr.Checked;
         _enableIcr   = _chkEnableIcr.Checked;
         _isNumerical = _radioTextNumerical.Checked;
         _name = _txtName.Text;
         _type = ConvertToProcessingFieldType(_cmbType.Text);
         _left = System.Convert.ToDouble(_txtLeft.Text);
         _top = System.Convert.ToDouble(_txtTop.Text);
         _width = System.Convert.ToDouble(_txtWidth.Text);
         _height = System.Convert.ToDouble(_txtHeight.Text);
         DialogResult = DialogResult.OK;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _chkEnableIcr.Checked = _enableIcr;
         _chkEnableOcr.Checked = _enableOcr;
         _radioTextNumerical.Checked = _isNumerical;
         _radioTextCharacter.Checked = !_isNumerical;         
         _txtName.Text = _name;
         _cmbType.Text = _type.ToString();
         _txtLeft.Text = _left.ToString();
         _txtTop.Text = _top.ToString();
         _txtWidth.Text = _width.ToString();
         _txtHeight.Text = _height.ToString();
         DialogResult = DialogResult.Cancel;
      }

      public bool EnableOcr
      {
         get { return _enableOcr; }
      }

      public bool EnableIcr
      {
         get { return _enableIcr; }
      }

      public bool IsNumerical
      {
         get { return _isNumerical; }
      }

      public string FieldName
      {
         get { return _name; }
      }

      public ProcessingFieldType FieldType
      {
         get { return _type; }
      }

      public LogicalRectangle FieldBounds
      {
         get { return new LogicalRectangle(_left, _top, _width, _height, LogicalUnit.Pixel); }
      }

      private void _cmbType_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (_cmbType.Text.CompareTo(ProcessingFieldType.Text.ToString()) == 0)
            {
               _typeGroup.Enabled = true;
               _methodGroup.Enabled = true;
            }
            else
            {
               _methodGroup.Enabled = false;
               _typeGroup.Enabled = false;
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }
   }
}
