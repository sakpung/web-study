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

namespace GrayScaleDemo
{
   public partial class FillDialog : Form
   {
      public int Level;
      public Color FillColor;
      private bool _isGray;
      private TypeConstants _type;

      public FillDialog(bool isGray,TypeConstants type)
      {
         InitializeComponent();
         _isGray = isGray;
         _type = type;
      }

      public enum TypeConstants
      {
         AddColorToRegion,
         Fill,
      }

      private struct TypeProp
      {
         public TypeConstants Type;
         public string CaptionName;

         public TypeProp(TypeConstants type, string captionName)
         {
            Type = type;
            CaptionName = captionName;
         }
      }

      private static TypeProp[] _typeProp = new TypeProp[]
        {
         new TypeProp(TypeConstants.AddColorToRegion,"Add Color To Region"),
         new TypeProp(TypeConstants.Fill,"Fill"),
      };

      private void FillDialog_Load(object sender, EventArgs e)
      {
         if (_isGray)
         {
           _pnlColor.Visible = false;
           _pnlLevel.Visible = true; 
         }
         else
         {
           _pnlColor.Visible = true;
           _pnlLevel.Visible = false; 
         }
         _numLevel.Value = 0;
         _pnlRevColor.BackColor = FillColor = Color.Black;

         TypeProp prop = _typeProp[(int)_type];
         Text = prop.CaptionName;
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Level = (int)_numLevel.Value;
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnDlgColor_Click(object sender, EventArgs e)
      {
         ColorDialog colorDlg = new ColorDialog();
         if (colorDlg.ShowDialog() == DialogResult.OK)
         {
            _pnlRevColor.BackColor = FillColor = colorDlg.Color;
         }
      }

   }
}
