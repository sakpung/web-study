// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.SpecialEffects;
namespace SpecialEffectsDemo
{
   public partial class TextDialog : Form
   {
      public TextDialog(TextOptions options)
      {
         _options = options;

         InitializeComponent();
      }

      private TextOptions _options;

      private void NewTextDialog_Load(object sender, EventArgs e)
      {
         ArrayList items = new ArrayList();

         items.Add(new ComboBoxItem("No 3D Effect", (int)SpecialEffectsTextStyle.Normal));
         items.Add(new ComboBoxItem("Inset Light", (int)SpecialEffectsTextStyle.InsetLight));
         items.Add(new ComboBoxItem("Inset Extra Light", (int)SpecialEffectsTextStyle.InsetExtraLight));
         items.Add(new ComboBoxItem("Inset Heavy", (int)SpecialEffectsTextStyle.InsetHeavy));
         items.Add(new ComboBoxItem("Inset Extra Heavy", (int)SpecialEffectsTextStyle.InsetExtraHeavy));
         items.Add(new ComboBoxItem("Raised Light", (int)SpecialEffectsTextStyle.RaisedLight));
         items.Add(new ComboBoxItem("Raised Extra Light", (int)SpecialEffectsTextStyle.RaisedExtraLight));
         items.Add(new ComboBoxItem("Raised Heavy", (int)SpecialEffectsTextStyle.RaisedHeavy));
         items.Add(new ComboBoxItem("Raised Extra Heavy", (int)SpecialEffectsTextStyle.RaisedExtraHeavy));
         items.Add(new ComboBoxItem("Drop Shadow", (int)SpecialEffectsTextStyle.DropShadow));
         items.Add(new ComboBoxItem("Block Shadow", (int)SpecialEffectsTextStyle.BlockShadow));
         items.Add(new ComboBoxItem("Outline Block", (int)SpecialEffectsTextStyle.OutlineBlock));

         _cmbTextStyle.DataSource = items;
         _cmbTextStyle.DisplayMember = "Display";
         _cmbTextStyle.ValueMember = "Value";

         _tbText.Text = _options.Text;

         for(int i = 0; i < _cmbTextStyle.Items.Count; i++)
         {
            ComboBoxItem item = (ComboBoxItem)_cmbTextStyle.Items[i];
            if(_options.Style == (SpecialEffectsTextStyle)item.Value)
            {
               _cmbTextStyle.SelectedIndex = i;
            }
         }

         _btnTextColor.BackColor = _options.TextColor;
         _btnBorderColor.BackColor = _options.BorderColor;
      }

      private void _btnTextColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _btnTextColor.BackColor = dlg.Color;
         }
      }

      private void _btnBorderColor_Click(object sender, EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _btnBorderColor.BackColor = dlg.Color;
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _options.Text = _tbText.Text;

         ComboBoxItem item = (ComboBoxItem)_cmbTextStyle.SelectedItem;
         _options.Style = (SpecialEffectsTextStyle)item.Value;

         _options.TextColor = _btnTextColor.BackColor;
         _options.BorderColor = _btnBorderColor.BackColor;
      }

      public TextOptions TextOptions
      {
         get
         {
            return _options;
         }
      }
   }
}
